DynamicList Inventory Tool v1.0

UI control that allows you to create dynamic lists depending on you gameobjects (e.g. inventory stuff)

Features:

*Simple implementation
*Horizontal or vertical orientation
*Binding items from editor as well as from code
*Mobile ready
*Drag'n'Drop support

Instructions:

1. Add DynamicList ViewModel to you canvas

2. Add ViewModelItem scripts to your gameobjects (In case of editor binding. Otherwise you have to create items from code. For more information for from-code binding see "SetItemsFromeCode" scene).

3. Add some icons for UI

4. Adjust visual style

5. Drag and drop your gameobjects with "ViewModelItem" scripts to "ListViewModel"'s ViewModels field (In case of editor binding. Otherwise you can bind items from code using "SetItemsSource" method of "ListViewModel" class. For more information about from-code binding see "SetItemsFromeCode" scene).

6. Handle ItemSelected event

7. You can enable drag'n'drop function with "IsDragNDropEnabled" field. You can also adjust adorner size with "AdornerSize" field. Simple drag'n'drop behaviour between ListViewModels implemented in "DropArea" script, so you can modify it for you purposes. But if you want to drag items on gameobjects you to have to use "ItemDragEnded" event of "ListViewModel" class. You can find examples in demo scene.