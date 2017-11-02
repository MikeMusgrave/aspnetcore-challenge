# aspnetcore-challenge
Code challenge using ASP.net CORE

Technical Requirements
 
Tools:
ASP.NET Core / MVC6
Public Git repo
Visual Studio 2017 Community Edition
DB (either embedded or remotely accessible)
 
Implement a Web API that responds to the following:
 
Model: 
FoodItem
• Id: Guid
• Name: string
• URL: string
• Email: string
• Rating: enum (RatingEnum)
 
GET: /api/food
• Returns a JSON list of food items 
  o List stored in memory is fine, DB better
  o If stored in memory, use abstraction layer so that DB could be plugged in later
  o If using DB, include script or access
• Find by id: /api/food/?id=GUID 
  o Returns a list of one or zero items
 
POST: /api/food
• Post a JSON body that contains a new food item 
  o List stored in memory is fine, DB better
  o Return a 400 response with validation details if there are validation errors
 
The following MVC views (not necessary to look nice):
• Listing page that lists all food items 
  o Clicking on a food item takes you to a detail page for the food item
• Page with a form that lets you search by id 
  o Either returns a no results message or displays the food item details
• Page with a form that lets you add a new food item 
  o Display validation messages (see validations below)
 
The following validations should be in place when POSTing to the API or adding an item via the MVC form:
• There should be the following field validations 
  o Name is required, <= 30 characters
  o ImageURL is optional,  <=512 characters
  o Email is optional, a valid email format, <= 256 characters
  o Rating is required, a valid rating
