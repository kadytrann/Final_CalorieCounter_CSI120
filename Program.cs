using static Final_CalorieCounter_CSI120.Program;

namespace Final_CalorieCounter_CSI120
/*
Kady Tran
6/10/2024
CSI 120
Final - Calorie Counter
 */
{
    internal class Program
    {
        // Array
        // Creating a FoodItem array with a size of 4
        static FoodItem[] foodItems = new FoodItem[2];

        static void Main(string[] args)
        {
            Preload(); // Calling our preloaded data 

            Menu(); // Calling our menu

        } // End of main


        // The menu method will display multiple choices for the user and will be prompting user for an input for their choice 
        public static void Menu()
        {
            while (true)
            {
                // displaying all options
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Display all the food you have eaten");
                Console.WriteLine("2. Add New Items");
                Console.WriteLine("3. Calculate your total calories eaten");
                Console.WriteLine("4. Calculate the average calories of an item you've eaten");
                Console.WriteLine("5. Display all food eaten of a certain category");
                Console.WriteLine("6. Search for a food item by name");
                Console.WriteLine("7. Exit");
                Console.Write("Please select an option (1-7): ");

                // prompting user for their choice
                string choice = Console.ReadLine();

                // start of switch statement
                switch (choice)
                {
                    case "1": // Display all the food you have eaten
                        DisplayAllFoodItems();
                        break;
                    case "2": // Add New Items
                        AddItem();
                        break;
                    case "3": // Calculate your total calories eaten
                        TotalCaloriesEaten();
                        break;
                    case "4": // Calculate the average calories of an item you've eaten
                        AverageCalorieEaten();
                        break;
                    case "5": // Display all food eaten of a certain category
                        DisplayByCategory();
                        break;
                    case "6": // Search for a food item by name
                        FindAndDisplayByName();
                        break;
                    case "7": // exit
                        Console.WriteLine("You have exited.");
                        return;
                    default: // if user inputs an invalid value
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                } // end of switch

                Console.WriteLine(); // Added a cw line for readability
            }


        } // Menu



        public static void Preload()
        {
            //inital data
            // adding beef and rice to start off the foodItems array
            foodItems[0] = new FoodItem("Beef", 3, 250, 1);
            foodItems[1] = new FoodItem("Rice", 4, 205, 1);

        } // Preload()


        static void DisplayAllFoodItems()
        {
            // this method will display all food items in the array
            // foreach ( TYPE varName in collection ) {}
            // this iterates through each item in our array
            foreach (FoodItem food in foodItems)
            {
                if (food != null) // checks to see if the item is not null 
                {
                    Console.WriteLine(food.DisplayInformation());
                }

            }
        } // DisplayAllFoodItems()




        // AddItem SECTION
        // method to add a new food item to the array
        static void AddItem()
        { // I copied and pasted from the canvas code from here
            // This method calls 3 separate methods

            // Ask user for item
            FoodItem newItem = MakeNewItem();

            // To to find last index
            int firstIndex = FindEmptyIndex();

        // If index is NOT found, double array size, then check again for first index
        if (firstIndex == -1)
            {
            IncreaseArraySize();
            firstIndex = FindEmptyIndex();
            }

            // Add item to first index
            foodItems[firstIndex] = newItem;

        // To here

            DisplayAllFoodItems(); // This will display all the food items after adding the new item
        } // AddItem()


        static FoodItem MakeNewItem()
        {
            // This method will ask the user for a name, category ( a list of numbers will be provided ), calories, quantity, and after all the information is added, it will return a new food item.

            // Asking for name
            Console.Write("Enter a food name: ");
            string foodName = Console.ReadLine();


            // Since we are putting it in a try catch statement, I will declare the variables outside of the while loop.
            // I am also putting it in a while loop to ensure the user will put the correct input. The user will not be able to continue onto the next question if the value is incorrect.

            // Variables for category, calories and quantity
            int category = 0;
            int calories = 0;
            int quantity = 0;

            // Asking for category name by number
            while (true)
            {
                Console.Write("Enter a Category name - 1 Fruit - 2 Vegetable - 3 Protein - 4 Grain - 5 Dairy: ");
                // Start of try catch statement
                try
                {
                    category = int.Parse(Console.ReadLine());
                    if (category < 1 || category > 5) // using if statement to ensure that if the user inputs a value that's under 1 or over 5, it will throw an error message and prompt the user again
                    {
                        Console.WriteLine("Please enter the correct number (1-5) for the category name.");
                        continue; // This will keep the loop going until the user puts the correct value
                    }
                    break; // exit the loop if parsing is successful and the value is within the valid range
                }
                catch
                {
                    Console.WriteLine("Please enter the correct number (1-5) for the category name."); 
                } // end of try catch statement
            }


            // Asking for number of calories
            while (true)
            {
                Console.Write("Enter number of calories: ");
                try
                {
                    calories = int.Parse(Console.ReadLine());
                    break; // exit the loop if parsing is successful
                }
                catch
                {
                    Console.WriteLine("Please enter a valid value for the number of calories.");
                }
            }

            // Asking for number of quantity
            while (true)
            {
                Console.Write("Enter number of quantity: ");
                try
                {
                    quantity = int.Parse(Console.ReadLine());
                    break; // exit the loop if parsing is successful
                }
                catch
                {
                    Console.WriteLine("Please enter a valid value for the number of quantity.");
                }
            }

            Console.WriteLine(); // This is to add space to make it look cleaner

            // With all the new data from the user, this will create a new food item
            FoodItem newFood = new FoodItem(foodName, category, calories, quantity);

            // This will return the new food item into our array ( putting it into the array )
            return newFood;
        } // MakeNewItem()


        static int FindEmptyIndex()
        {
            // Go through each element in the array

            for (int i = 0; i < foodItems.Length; i++)
            {
                // checking to see if a spot in the array is null
                FoodItem temp = foodItems[i];

                if (temp == null)
                {
                    // returning the index of the empty space
                    return i;
                }

            }

            // If no empty space is found, return -1
            return -1;
        } // FindEmptyIndex()


        static void IncreaseArraySize()
        {
            // Make a temp array double the size of the first array
            FoodItem[] tempArray = new FoodItem[foodItems.Length * 2];

            // Move the elements from the first array to the second
            for (int i = 0; i < foodItems.Length; i++)
            {
                tempArray[i] = foodItems[i];
            }

            // Replace the original array with the new one
            foodItems = tempArray;
        } // IncreaseArraySize()


        static double TotalCaloriesEaten()
        {
            // this method should loop through the array and sum the total calories eaten of all items
            // declaring our total calories variable
            double totalCalories = 0;

            // using foreach for our loop method to search through our array 
            // for every total calories of each food item, it will be calculated towards our total calories variable 
            foreach (FoodItem food in foodItems)
            {
                if (food != null)
                {
                    totalCalories += food.TotalCalories();
                }
                
                
            } // End of foreach
            Console.WriteLine($"Your total calories are {totalCalories}");
            // Result : Your total calories are 305
            return totalCalories; // this will return our value to the variable we declared above

        } // TotalCaloriesEaten()


        static double AverageCalorieEaten()
        {
            // Should loop through your array and get the average item calorie that you have added
            // Get the total calories eaten from the method above
            double totalCalories = TotalCaloriesEaten();

            // the foreach loop will be counting the number of food items
            int foodCount = 0;
            foreach (FoodItem food in foodItems)
            {
                if (food != null)
                {
                    foodCount++;
                }
            } //end of foreach

            // Calculating the average from the total calories dividing it by the number of food items
            // putting it in a if statement so that the foodCount is not a zero to avoid division error
            double averageCalories = 0;
            if (foodCount > 0)
            {
                averageCalories = totalCalories / foodCount;
            }
            Console.WriteLine($"Youe average calories are {averageCalories}");
            return averageCalories;
        } // AverageCalorieEaten()


        static void DisplayByCategory()
        {
            //Create a method that will ask the user to select a category
            // This will display all items only in that category 

            // Display message
            Console.Write("Please select a category (Fruit, Vegetable, Protein, Grain, Dairy): ");
            // storing user input into a string
            string userCategory = Console.ReadLine().ToLower(); // using to lower so a user can put in lowercase input and it will still direct them to the right category

            // We are going to convert the selected category that was submitted in string form to become an int in order to have it correspond to the category number that we've set it to in our CategoryName method
            int categoryNumber = 0;

            switch (userCategory)
            {
                case "fruit":
                    categoryNumber = 1;
                    break;
                case "vegetable":
                    categoryNumber = 2;
                    break;
                case "protein":
                    categoryNumber = 3;
                    break;
                case "grain":
                    categoryNumber = 4;
                    break;
                case "dairy":
                    categoryNumber = 5;
                    break;
                default: // This default will make sure that any other value that was inputted will display the message "no category chosen"
                    Console.WriteLine("No Category Chosen");
                    return;

            } // end of switch

            // Now we will display all the items in the category the user selected
            bool itemFound = false; 
            //using a foreach loop in order to look through our array (linear searching)
            foreach (FoodItem food in foodItems)
            {
                if (food != null && food.Category == categoryNumber) 
                {
                    Console.WriteLine(food.DisplayInformation());
                    itemFound = true;
                }
            }

            if (!itemFound) // if the item was not found, this will set the bool to true and will display the message below
            {
                Console.WriteLine($"No items found in the {userCategory} category.");
            }

        } // DisplayByCategory()


        // Finding by name
        // Separate our method into 2 parts
        // 1. Is find by name
        // 2. Is display result
        public static int DisplayItemWithName(string foodName)
        {
            foodName = foodName.ToLower(); // putting .ToLower so that the user can find it without having to use uppercase letters


            // using for loop to search through our array and find the name of the food
            for (int i = 0; i < foodItems.Length; i++)
            {
                FoodItem currentFood = foodItems[i];

                if (foodName == currentFood.Name.ToLower())
                {
                    return i; // if the name was found, it will return the index
                }

            } // end of for loop

            // Return -1 if the food is not found 
            return -1;
        } // DisplayItemWithName()


        // Display information based on if a food is found or not
        public static void DisplayByName(int foodIndex)
        {
            // our second separate method to display the food information from just the name
            if (foodIndex == -1) // -1 means that it was not found
            {
                Console.WriteLine("That food does not exist");
            }
            else // if it was found, it will display food information
            {
                FoodItem foodByName = foodItems[foodIndex];
                Console.WriteLine(foodByName.DisplayInformation());
            }

        } // DisplayByName()


        // Here will be calling our 2 seperate methods and putting it into one method
        public static void FindAndDisplayByName()
        {
            // asking user input for a name of food and using the input to find the food
            Console.Write("Enter a name to search for: ");
            string userInput = Console.ReadLine();

            int nameIndex = DisplayItemWithName(userInput);

          // calling our displaybyname method in order to display information
            DisplayByName(nameIndex);
        } // FindAndDisplayByName()




        // CLASS Section

        // Here we are creating our class called Food Item
        public class FoodItem
        {
            // Fields
            public string Name;
            public int Category;
            public int Calories;
            public int Quantity;

            // Constructors
            public FoodItem(string name, int category, int calories, int quantity)
            {
                Name = name;
                Category = category;
                Calories = calories;
                Quantity = quantity;
            }

            // Default Constructor
            public FoodItem() // This constructor will be for placeholding
            {
                Name = "No Item Listed";
                Category = -1;
                Calories = -1;
                Quantity = -1;
            }


            // Methods inside our class


            public double TotalCalories()
            {
                // This method does the calculation to return the total calories of an instance of the instanced object
                return Quantity * Calories;

            } // TotalCalories()

            public string CategoryName()
            {
                // This method takes the category number assigned and returned the proper category name.
                /*
                    1 Fruit
                    2 Vegetable
                    3 Protein
                    4 Grain
                    5 Dairy
                For any other number put "No Category Chosen"
                */

                // we are creating the categoryName string variable in order for this method to return the string with the proper category name based on the number
                string categoryName = "";

                // using switch would be best when asking for an input for multiple options 
                switch (Category)
                {
                    case 1:
                        categoryName = "Fruit";
                        break;
                    case 2:
                        categoryName = "Vegetable";
                        break;
                    case 3:
                        categoryName = "Protein";
                        break;
                    case 4:
                        categoryName = "Grain";
                        break;
                    case 5:
                        categoryName = "Dairy";
                        break;
                    default: // This default will make sure that any other number that was inputted will display the message "no category chosen"
                        categoryName = "No Category Chosen";
                        break;

                }

                return categoryName;

            } // CategoryName()

            public string DisplayInformation()
            {
                // This method will return items' information in a formatted string
                /*
                Name: Apple
                Category : Fruit
                Calories : 95
                Quantity : 1
                Total Calorites : 95
                 */

                string formattedString = "";
                formattedString += Name + "\n"; // Name
                formattedString += CategoryName() + "\n"; // Category
                formattedString += Calories + "\n"; // Calories
                formattedString += Quantity + "\n"; // Quantity
                formattedString += $"Total Calories: {TotalCalories()} \n"; // Total Calories : Total Calories

                return formattedString;


            } // DisplayInformation()




        } // End of FoodItems Class





        }// End of class
    }// End of name space



