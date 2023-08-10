# BlogManagementSystem
Create a blog management system where Readers can subscribe for different blogs. The system should also include an approval workflow where an admin approves or rejects the newly created Blogs. Only approved Blogs should be available to Readers for subscription.
Below are the lists of screens to be made:
●Use standard Registration and Login feature of .Net Core Identity
●Create screens for CRUD Operation of Blogs. This should include details like Blog Title, Blog Content, Blog Category and number of subscriptions allowed.
●Create a screen to list out all Blogs which are pending for approval by Admin. This screen should list only those records, for which approval/rejection decision is not taken. Approved or Rejected records should not appear on this screen.
●Blog Subscription– Create screens for CRUD operation of Blog Subscription. Readers can select a blog and subscribe for the same. Once the subscription is done, available subscription count should be reduced. Similarly, deleting a subscription should increase the available subscription count.
●Implement a View Component to show the title of the Blog on the blog list page, which is subscribed most number of times, 
●Blog listing task should use the concept of Partial views
●Where to use View Bag/View Data/Temp Data, Toaster Notification, and Session is not explicitly specified. You should decide on your own where to use it.
●You must apply obvious validations for the input fields which are not explicitly mentioned.
General Guidelines:
●The Solution should have minimum 3 projects - Web Application, Web API and a class Library project that will have the code for all DB related operation
●The Authentication and Authorization should be implemented in both Web application (Using .Net Core Identity) and Web API (Using JWT)
●The database layer should have implementation of Repository Pattern
●All Model Mapping should be done using Auto Mapper
●Unit of Work is not must to do, if you do it that is good.
●The database table column type, length etc. should be meaningful and should be handled through right data annotations in model classes
●You must not copy/paste the code structure from training material. There is no harm in referring that material or any other material from internet as a reference, but try to write your own code which will give you more confidence on doing the things from scratch. If I see the pattern blindly copied from course content like it was done for the API assignment, then the marks will be deducted for the same.
