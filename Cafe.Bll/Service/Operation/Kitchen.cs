using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.Operation.Processing;
using Cafe.DI.Interfaces.Recipe;

namespace Cafe.Bll.Service.Operation
{
    /// <summary>
    /// The class responsible for cooking.
    /// </summary>
    public class Kitchen
    {
        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="ingredientsStorages"></param>
        /// <param name="processing"></param>
        /// <param name="orders"></param>
        /// <param name="recipes"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Kitchen(List<IIngredientsStorage> ingredientsStorages,
            List<IProcessing> processing, List<IOrder> orders, List<IRecipe> recipes)
        {
            if (ingredientsStorages == null)
                throw new ArgumentNullException(nameof(ingredientsStorages));

            if (processing == null)
                throw new ArgumentNullException(nameof(processing));

            if (orders == null)
                throw new ArgumentNullException(nameof(orders));

            if (recipes == null)
                throw new ArgumentNullException(nameof(recipes));

            IngredientsStorages = ingredientsStorages;
            Processing = processing;
            Orders = orders;
            Recipes = recipes;
        }

        /// <summary>
        /// A class describing the chef and his capabilities.
        /// </summary>
        public static class Chief 
        {
            public static string Name { get; }

            /// <summary>
            /// Adding a new recipe.
            /// </summary>
            /// <param name="product"></param>
            /// <exception cref="ArgumentNullException"></exception>
            public static void CreateRecipe(IRecipe product)
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));

                Recipes.Add(product);
            }

            /// <summary>
            /// Create an order.
            /// </summary>
            /// <param name="order"></param>
            public static void ExecuteOrder(IOrder order)
            {
                if(order==null)
                    throw new ArgumentNullException(nameof(order));

                var recipes = GetRecipes(order);

                StartProcess(recipes);

            }
        }

        /// <summary>
        /// The method responsible for calling the treatments.
        /// </summary>
        /// <param name="recipes"></param>
        private static void StartProcess(List<IRecipe> recipes)
        {
            foreach (var item in recipes)
            {
                List<(IIngredient, int)> ingredients = GetIngredient(item);

                foreach (var step in item.CookingSteps)
                {
                    foreach (var process in Processing)
                    {
                        process.Execute();
                    }
                }
            }
        }

        /// <summary>
        /// The method responsible for getting the right ingredients from storage.
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        private static List<(IIngredient, int)> GetIngredient(IRecipe recipe)
        {
            var list = new List<(IIngredient, int)>();

            foreach (var item in recipe.Ingredients)
            {
                foreach (var storage in IngredientsStorages)
                {
                    (IIngredient, int) ingredient =
                        storage.GetIngredients(item.Item1.TypeOfIngredient, item.Item2);

                    if (ingredient.Item1 != null)
                    {
                        list.Add(ingredient);
                        break;
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Getting the right recipes depending on the user's order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private static List<IRecipe> GetRecipes(IOrder order)
        {
            var recipes = new List<IRecipe>();

            foreach (var item in Recipes)
            {
                foreach (var meal in order.GetAll())
                {
                    if ((item.TypeOfProduct, item.Name) == (meal.TypeOfProduct, meal.Name))
                    {
                        recipes.Add(item);
                    }
                }
            }

            return recipes;
        }

        public static List<IIngredientsStorage> IngredientsStorages { get; set; }

        public static List<IProcessing> Processing { get; set; }

        public static List<IOrder> Orders { get; set; }

        public static List<IRecipe> Recipes { get; set; }
    }
}
