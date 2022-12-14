# starter template for aspcore 6 jwt token docker redis

## What is this?
- starter template for aspcore with Identity API

## How to use?

### create user
use csproj ExploreIdentityServer6  
dotnet run  
register user from website  
http://localhost:5000/Identity/Account/Register

username: user1@user.com  
password: Password1%

database on sqlite  
"ConnectionStrings": {
"DefaultConnection": "DataSource=app.db;Cache=Shared"
},

### get token
use csproj ExploreIdentityServer6  
dotnet run  

get token from users/login [HttpGet]  
http://localhost:5000/Users/Login?username=user1@user.com&password=Password1%

### consume token from postman
use csproj LogicOne  
use postman  
get API result from /home/InquiryStudent/2 [HttpGet]  
dont forget to push bearer token on header  
http://localhost:5010/home/InquiryStudent/2

### call indirect from identity server
use csproj ExploreIdentityServer6
use postman
get API result from  /debugMicro/GetStudent [HttpGet]
dont forget to push bearer token on header
http://localhost:5000/debugMicro/GetStudent

### send item to redis
http://localhost:5010/DebugExt/SendMessageRedis

### redis console listener
use csproj RedisListenerConsole  
dotnet run

## How to deploy?
use docker compose  
docker-compose up --build
