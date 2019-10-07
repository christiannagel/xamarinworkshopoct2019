# Lab 1

1. Create a Xamarin.Android Project
2. Add a button to the form
3. Add a event handler to show a toast on click of the button
4. Run the application using an emulator

## Show a List

1. Create a model type, e.g. a `Book` type
2. Create a factory to create a list of the `Book` types
3. Create a new activity to show a list - derive from the `ListActivity`
4. Start the activity from a button click in the first activity
5. Create an adapter deriving from the base adapter `BaseAdapter`
6. Return a view for the items in the custom adapter in the `GetView` method, e.g. the view Android.Resource.Layout.SimpleListItem1
7. Run the application using an emulator