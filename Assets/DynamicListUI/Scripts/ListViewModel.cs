using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.DynamicListUI.Scripts
{

    public class ListViewModel : MonoBehaviour
    {
        public const string ContentImageButtonName = "ContentImage";
        public const string ContainerImageButtonName = "ContainerImage";

        private RectTransform _rectTransform;

        private Button _sampleButton;

        public ListItemViewModel[] ViewModels;

        public ListItemViewModel SelectedItem { get; set; }

        public Button SelectedButton { get; set; }

        private List<Button> _buttons = new List<Button>();

        public Color SelectedContentColor;

        public Color DefaultContentColor;

        public Color SelectedContainerColor;

        public Color DefaultContainerColor;

        public bool IsDragNDropEnabled;

        public event SelectedHandler ItemSelected;

        public event DragEndHandler ItemDragEnded;

        public bool HighlightContainerIfSelected = true;

        public bool HighlightContentIfSelected = true;

        public bool ApplyColorsFromItems;

        public Adorner Adorner { get; set; }

        public float AdornerSize = 0.5f;

        public delegate void SelectedHandler(object sender, ListItemViewModel args);

        public delegate void DragEndHandler(object sender, DragEndedEventArgs args);

        private RectTransform _dynamicListRect;


        void Awake()
        {
            Init();

            if (ViewModels.Any())
                GenerateList();
        }

        public void Init()
        {
            Adorner = FindObjectOfType<Adorner>();

            ResetInEditor();
            _rectTransform = GetComponent<RectTransform>();
            _dynamicListRect = GetComponentInParent<DynamicList>().GetComponent<RectTransform>();
            _sampleButton = GetComponentsInChildren<RectTransform>().Single(x => x.name == "SampleButton").GetComponent<Button>();
            _sampleButton.gameObject.SetActive(false);
            _sampleButton.GetComponent<DragHandler>().enabled = IsDragNDropEnabled;
        }

        public void ResetInEditor()
        {
            var buttons = GetComponentsInChildren<RectTransform>().Where(x => x.name.Contains("DynamicButton")).ToList();
            foreach (var button in buttons)
            {
                DestroyImmediate(button.gameObject);
            }


            GetComponentsInChildren<RectTransform>(true).Single(x => x.name == "SampleButton").GetComponent<Button>().gameObject.SetActive(true);
        }

        /// <summary>
        /// Команда по кнопке. При этом выбранная viewmodel берётся из коллекции вьюмоделей по InstanceId кнопки
        /// </summary>
        public void SelectItem()
        {
            SelectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            var selectedVm = FindViewModelItemByButton(SelectedButton);
            SelectedItem = selectedVm;
            ResetSelectedColors();
            SetSelectedColor(SelectedButton);
            SendSelectedMessage();
        }

        public ListItemViewModel FindViewModelItemByButton(Button button)
        {
            return ViewModels.FirstOrDefault(listItemViewModel => listItemViewModel.Button == button);
        }

        /// <summary>
        /// Команда установки выбранной viewmodel из кода. При этом кнопка ищется в коллекции _buttons по InstanceId
        /// </summary>
        /// <param name="item"></param>
        public void SetSelectedItem(ListItemViewModel item)
        {
            SelectedButton = _buttons.Single(x => x == item);
            SelectedItem = item;
            ResetSelectedColors();
            SetSelectedColor(SelectedButton);
            SendSelectedMessage();
        }

        private void SendSelectedMessage()
        {
            if (ItemSelected != null)
            {
                ItemSelected(this, SelectedItem);
            }
        }

        public void ResetSelectedColors()
        {
            var buttons = Application.isPlaying ? _buttons :
                    GetComponentsInChildren<RectTransform>()
                    .Where(x => x.name.Contains("DynamicButton"))
                    .Select(x => x.GetComponent<Button>()).ToList();

            foreach (var button in buttons)
            {
                var image = GetContentImage(button);
                var color = ApplyColorsFromItems ? FindViewModelItemByButton(button).Color : DefaultContentColor;
                image.color = color;
                image = GetContanerImage(button);
                image.color = DefaultContainerColor;
            }
        }

        public void SetContentColor(Color color)
        {
            var image = GetContentImage(SelectedButton);
            image.color = color;
        }

        public void SetSelectedColor(Button element)
        {
            if (HighlightContentIfSelected)
            {
                var image = GetContentImage(element);
                image.color = SelectedContentColor;
            }

            if (HighlightContainerIfSelected)
            {
                var image = GetContanerImage(element);
                image.color = SelectedContainerColor;
            }
        }

        public void SetItemsSource(ListItemViewModel[] items)
        {
            ViewModels = items;
            GenerateList();
        }

        public void AddItem(ListItemViewModel item)
        {
            var newList = ViewModels.ToList();
            newList.Add(item);
            SetItemsSource(newList.ToArray());
        }

        public void RemoveItem(ListItemViewModel item)
        {
            var newList = ViewModels.ToList();
            newList.Remove(item);
            SetItemsSource(newList.ToArray());
        }

        public Image GetContentImage(Button mainButton)
        {
            return mainButton.GetComponentsInChildren<Image>().Single(x => x.name == ContentImageButtonName);
        }

        public Image GetContanerImage(Button mainButton)
        {
            return mainButton.GetComponentsInChildren<Image>().Single(x => x.name == ContainerImageButtonName);
        }

        public void GenerateList()
        {
            _buttons.ForEach(x => Destroy(x.gameObject));
            _buttons.Clear();

            for (int i = 0; i < ViewModels.Length; i++)
            {
                var viewModel = ViewModels[i];
                var button = Instantiate(_sampleButton, _rectTransform);

                button.name = "DynamicButton";

                button.name = button.name + i;

                button.gameObject.SetActive(true);

                var rect = button.GetComponent<RectTransform>();
                var contentImage = button.GetComponentsInChildren<Image>().Single(x => x.name == "ContentImage");
                if (viewModel.Sprite != null) contentImage.sprite = viewModel.Sprite;

                if (ApplyColorsFromItems) contentImage.color = viewModel.Color;

                if (Application.isPlaying)
                {
                    _buttons.Add(button);
                }

                viewModel.Button = button;
            }

            if (Application.isPlaying)
            {
                var grid = GetComponent<GridLayoutGroup>();
                var lines = Mathf.Ceil(ViewModels.Length / (float)grid.constraintCount);

                switch (grid.constraint)
                {
                    case GridLayoutGroup.Constraint.Flexible:
                        break;
                    case GridLayoutGroup.Constraint.FixedColumnCount:
                        _rectTransform.sizeDelta =
                            new Vector2(_rectTransform.sizeDelta.x, (grid.cellSize.y + grid.spacing.y) * lines - _dynamicListRect.rect.height - grid.spacing.y);
                        break;
                    case GridLayoutGroup.Constraint.FixedRowCount:
                        _rectTransform.sizeDelta =
                            new Vector2((grid.cellSize.x + grid.spacing.x) * lines - _dynamicListRect.rect.width - grid.spacing.x, _rectTransform.sizeDelta.y);
                        break;
                }
            }

            ResetSelectedColors();

            _sampleButton.gameObject.SetActive(false);
        }

        public void OnDragEnd(Button button, GameObject target)
        {
            if (ItemDragEnded != null)
            {
                ItemDragEnded(this, new DragEndedEventArgs
                {
                    Item = ViewModels.Single(x => x.Button == button),
                    Target = target

                });
            }
        }
    }
}
