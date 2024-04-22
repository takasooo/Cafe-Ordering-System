# Cafe Ordering System Demo

**Menu Display:**
- When the application starts, it displays a list of all available dishes in the café.
- Each dish is shown with its name, description, list of ingredients, and price.

**Ordering a Dish:**
- The user can order a dish by entering its name.
- The system assigns the order to a cook with the least number of dishes in progress.
- Each cook can handle up to 5 dishes simultaneously.
- If all cooks are currently busy, the system displays a message stating "No cooks available".

**Cook Class:**
- The Cook class represents a cook in the café.
- It has a field for the cook's name.
- It keeps track of the dishes assigned to the cook.

**Ingredient Class:**
- The Ingredient class represents an ingredient used in dishes.
- It has fields for the ingredient's name and price.

**Dish Class:**
- The Dish class represents a dish available in the café.
- It has fields for the dish's name, description, price, and estimated cooking time.
- Each dish is composed of a list of ingredients.

**Ordering Process:**
- When a dish is ordered, the system checks for an available cook.
- If a cook is available, the dish is assigned to them, and its cooking time is added to the cook's workload.
- The system calculates the estimated cooking finish time based on the number of dishes assigned to the cook.

**Error Handling:**
- The system handles cases where the user inputs an invalid dish name or when all cooks are busy.
- It provides appropriate error messages to the user in such cases.
