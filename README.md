# Acceptance Test
No. | Case Name | Username | Password | Expected Result
--- | --- | --- | --- | ---
*#1* | user กรอก username และ password ถูกต้อง | "ploy" | "Sck1234" | `{"status": "OK", "data": {"id": 1, "username": "ploy", "displayname": "พลอย"}}`
*#2* | user กรอก username ถูกต้อง แต่ password ผิด | "ploy" | "1234" | `{status: "ERROR", "message": "User not found"}`
*#3* | user กรอก username ผิด แต่ password ถูก | "nut" | "Sck1234" | `{status: "ERROR", "message": "User not found"}`
*#4* | user กรอก username และ password ผิด | "nut" | "1234" | `{status: "ERROR", "message": "User not found"}`
*#5* | user ไม่ได้กรอก username | "" | "Sck1234" | `{status: "ERROR", "message": "Username and Password are required."}`
*#6* | user ไม่ได้กรอก password | "ploy" | "" | `{status: "ERROR", "message": "Username and Password are required."}`
*#7* | user ไม่ได้กรอกทั้ง username และ password | "" | "" | `{status: "ERROR", "message": "Username and Password are required."}`

# A-DAPT Blueprint

![Info](https://raw.githubusercontent.com/zyracuze/dotnet-api-login/master/adapt.jpg)

# Run Acceptance Test
Must start the API before run acceptance test by newman

## Start API
```sh
dotnet run --project src/api/api.csproj
```

## Run Newman
```sh
newman run tests/api.AcceptanceTest/newman_acceptance_test.json
```

# Run Unit Test
```sh
dotnet test tests/api.UnitTest/api.UnitTest.csproj
```

# Run Integration Test
```sh
dotnet test tests/api.IntegrationTest/api.IntegrationTest.csproj
```

# Jenkins
http://139.59.108.209:8080/view/Dotnet-api-login/

# Coverage Report
https://sonarcloud.io/dashboard?id=sck-dotnet-api-login

# AppVeyor
https://ci.appveyor.com/project/ifew/dotnet-api-login

# Login API Endpoint
http://128.199.249.22:5000/api/login