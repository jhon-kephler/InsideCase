
# Inside Case

This is a case project for the selection process

## Documentation

[Diagrams](https://miro.com/welcomeonboard/QnVOWktEM1A3Tk02TGNVMU42dTZ3WHJlUnBOTWxTWDRmelJ5YUVzQnVnVUo5aURER1poRmZtQm9Mbkh1T3RTQ3wzNDU4NzY0NTg0MTk1OTExODM3fDI=?share_link_id=220806220436)

## How to

Install [SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) ASP.Net Core 8

Install [Docker](https://docs.docker.com/desktop/install/windows-install/) 

### Get Start

In the console entry under InsideCase\InsideCaseDB and use the command

#### Database project

```bash
  docker-compose up -d

  docker container ls

  docker inspect "CONTAINER ID" for image postgres
```

Open [Localhost](http://localhost:8080/) 

#### Backend project

Open project InsideCase.sln and run project

### Database Credentials

#### Login PgAdmin:

- Email: admin@insidecase.com
- Password: 1nSid3C@se1

#### Adding new server:

##### In General:
- Name: Inside_Case

##### In Connection:
- Host name/address: Use gateway IP to inspect return docker
- Username: sa
- Password: 1nSid3C@se

### Project Execution Guide

- Select a definition
  - Product API

- Add product
  ```bash
    Post - /api/product/Product/Create
  ```
  
- Get product by Id
  ```bash
    Get - /api/product/Product?Id=
  ```

- Get list product Paginated
  ```bash
    Get - /api/product/Product/List?PageNumber=1&PageSize=10
  ```

- Delete product by Id
  ```bash
    Delete - /api/product/Product/Delete?Id=0
  ```

- Switch to
  - Order API

- Create order
  ```bash
    /api/order/order/Order
  ```

- Close order
  ```bash
    Post - /api/order/Order/Close
    Request
            {
              "order_Id": 0,
              "produtos": [
                {
                  "id": 0,
                  "quantidade": 0
                }
              ]
            }
  ```

- Get order by Id
  ```bash
    Get - /api/order/Order?Id=0
  ```

- Get list of paginated orders with Closed order filter
  ```bash
    Get - /api/order/Order/List?PageNumber=1&PageSize=10
    Get - /api/order/Order/List?Closed=true&PageNumber=1&PageSize=10
  ```

- Delete order by Id
  ```bash
    Delete - /api/order/Order/Delete?Id=0
  ```
