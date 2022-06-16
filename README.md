SpringCoAccountAPI

## How to setup project
- Clone Project from github
- Open the solution file
- Clean, Rebuild and Build Solution
- Restore Nuget Packages
- Run Application.

## EndPoints and Payloads
GET: 
https://{localhost}/api/Accounts
POST:
https://{localhost}/api/Accounts
Payload:
{
  "productType": "string",
  "rate": 0,
  "createdAt": "2022-06-16T20:23:36.071Z"
}
https://{localhost}/api/customers/GetCustomer/{id}
GET: 
https://{localhost}/api/Accounts/{Id}
PUT: 
https://{localhost}/api/Accounts/{Id}
DELETE: 
https://{localhost}/api/Accounts/{Id}
POST:
https://{localhost}/api/Accounts/CreditAccount
Payload:
{
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "depositAmount": 0,
  "accountType": "string"
}
POST:
https://{localhost}/api/Accounts/DebitAccount
Payload:
{
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "depositAmount": 0,
  "accountType": "string"
}
POST:
https://{localhost}/api/Accounts/CreateCustomerAccount
Payload:
{
  "accountType": "string",
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}


GET: 
https://localhost:7108/api/customers/GetCustomers
GET: 
https://{localhost}/api/customers/GetCustomer/{id}
POST:
https://{localhost}/api/customers/PostCustomer
Payload:
{
  "firstName": "string",
  "lastName": "string",
  "emailAddress": "string",
  "mobileNo": "string",
  "active": true,
  "created": "2022-06-16T20:48:26.620Z",
  "updated": "2022-06-16T20:48:26.620Z",
  "deleted": "2022-06-16T20:48:26.620Z",
  "accountNumber": "string",
  "balance": 0
}
GET: 
https://{localhost}/api/customers/CreateCustomerDetails/{CustomerId}
DELETE: https://{localhost}/api/customers/DeleteCustomer/{id}
