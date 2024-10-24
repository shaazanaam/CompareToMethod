namespace CompareToMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
              new Item{ Value = 10},
              new Item{ Value = 5},
              new Item{ Value = 20},


            };
            items.Sort();

            foreach (Item item in items) { Console.WriteLine(item.Value ); }

            
            Console.ReadKey();
        }
    }
    public class Item : IComparable<Item>
    {
        public int Value { get; set; }

        public int CompareTo(Item? other)
        {
            if (other == null) return 1;

            { 
                return this.Value.CompareTo(other.Value);
            
            }
        }

    }
}


/*Connection Between CompareTo and Sort
The CompareTo method is crucial for sorting because it defines
how two objects of the same type are compared. 
When you call the Sort method on a collection, such as a List<T>, the sorting algorithm needs a way to determine the order of the elements. This is where CompareTo comes in.

How CompareTo Works with Sort
CompareTo Implementation: By implementing the CompareTo method in your class, you provide a way to compare two instances of that class.
Sorting Algorithm: When you call Sort on a list of objects, the sorting algorithm repeatedly calls the CompareTo method to determine the order of the elements.
Example with List<Item>
Using a List<Item> in the example demonstrates how the CompareTo method is used in practice. Here’s a step-by-step explanation:

Define the Item Class: Implement the CompareTo method to compare Item objects based on their Value property.
Create a List of Items: Populate a list with Item objects.
Sort the List: Call the Sort method on the list. The Sort method uses the CompareTo method to order the items.

Summary
CompareTo Method: Defines how two objects are compared.
Sort Method: Uses CompareTo to order elements in a collection.
Example: Shows how to implement and use CompareTo in a practical context. 

How Sort Works with CompareTo
Interface Contract: When you implement the IComparable<T> interface in your class, you are essentially telling the .NET framework
that your class has a method (CompareTo) that can be used to compare instances of your class.
Sorting Algorithm: The Sort method in the .NET framework is designed to work with any type that implements IComparable<T>. 
It knows that if a type implements this interface, it can call the CompareTo method to determine the order of elements.
Behind the Scenes
When you call Sort on a list of objects, the sorting algorithm (like QuickSort, MergeSort, etc.) 
needs to compare elements to decide their order. Here’s what happens:

Check for Interface: The Sort method checks if the elements in the list implement IComparable<T>.
Call CompareTo: If they do, the sorting algorithm calls the CompareTo method to compare elements.


public void Sort<T>(List<T> list) where T : IComparable<T>
{
    // Simplified sorting logic
    for (int i = 0; i < list.Count - 1; i++)
    {
        for (int j = i + 1; j < list.Count; j++)
        {
            if (list[i].CompareTo(list[j]) > 0)
            {
                // Swap elements
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
AI-generated code. Review and use carefully. More info on FAQ.
Why You Don’t See the Call
Abstraction: The .NET framework abstracts away the details of the sorting algorithm. You don’t need to write code to call CompareTo directly; the framework handles it for you.
Interface Implementation: By implementing IComparable<T>, you provide the necessary method (CompareTo) that the sorting algorithm uses.
Summary
IComparable<T> Interface: Tells the framework that your class can be compared.
Sort Method: Automatically uses CompareTo to compare elements.
Abstraction: The framework handles the details, so you don’t need to call CompareTo explicitly.
 
 */
