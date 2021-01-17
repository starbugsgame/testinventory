Objects Injector 1.0

This tool simplifies object attachment, e.g. inventory stuff.


1. Attach objects to your parent object (e.g. player hand) in the exact place you want. You can disable them afterwards.
2. Add ObjectInjector script to the parent object and set count of objects that you've attached ("Items" field)
3. Move objects you attached to slots in Item array

Now you can use ObjectsInjector functions in play mode:

 //Attach object by index
    
public void Insert(int index)

//Attach next item
    
public void InsertNext()

//Detach current item
    
public void DetachCurrent()


