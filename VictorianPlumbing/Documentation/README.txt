Hi Victorian Plumbing, Thank you for considering my application. 

The database can be found at the root of the repo called VictorianPlumbing.bacpac to insert into Microsoft SQL Server

For the API, The following JSON Object was used for my example. All requests were made with Postman as I did not configure the app to use Cors.

{
    "ID": 1,
    "Status": "Processing",
    "Account":{
        "Email": "morgan.bradbury@test.co.uk",
        "FirstName": "Morgan",
        "LastName": "Bradbury",
        "PhoneNumber": "01772123456"
    },
    "Currency": "USD",
    "OrderedItems": [
        {
            "ID": 1,
            "Name": "Book",
            "Quantity": 2,
            "Price": "6.41"
        },
        {
            "ID": 2,
            "Name": "Pen",
            "Quantity": 5,
            "Price": "2.99"
        }
    ]
}

All Controllers can be found in the root project.

All Models can be found in the VictorianPlumbing.Models Class Library

All Services can be found in the VictorianPlumbing.Services Class Library, along with their relevant Interfaces.

