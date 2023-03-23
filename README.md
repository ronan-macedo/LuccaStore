
# Lucca Store POC

A store application with front-end and back-end. Using clean architecture in the api side, and angular framework in the client side.


![MIT License](https://img.shields.io/badge/License-MIT-green.svg)

## Author

- [Ronan Macedo](https://github.com/ronan-macedo)

## Run API locally
1 - Go to the docker folder, open the "*cmd*", and run the following command:
```
docker-compose up -d --build
```
2 - Go to Visual Studio, set "*LuccaStore.Infrastructure*" project as startup project.

3 - In the "*Package Manager Console*" select the project mentioned before as default, and run:
```
update-database
```
Now you are ready to go!

## Tech Stack

**Client:**
|                                                          Icon                                                                 |      Name       |
| :---------------------------------------------------------------------------------------------------------------------------: | :-------------: |
| <img height="50" src="https://user-images.githubusercontent.com/25181517/183890595-779a7e64-3f43-4634-bad2-eceef4e80268.png"> |      Angular    |
| <img height="50" src="https://user-images.githubusercontent.com/25181517/183890598-19a0ac2d-e88a-4005-a8df-1ee36782fde1.png"> |    TypeScript   |
| <img height="50" src="https://user-images.githubusercontent.com/25181517/183898674-75a4a1b1-f960-4ea9-abcb-637170a00a75.png"> |        CSS      |

**Server:** 
|                                                          Icon                                                                 |      Name       |
| :---------------------------------------------------------------------------------------------------------------------------: | :-------------: |
| <img height="50" src="https://user-images.githubusercontent.com/25181517/121405384-444d7300-c95d-11eb-959f-913020d3bf90.png"> |       C#        |
| <img height="50" src="https://user-images.githubusercontent.com/25181517/121405754-b4f48f80-c95d-11eb-8893-fc325bde617f.png"> |    .NET Core    |

<p align="center">
	<img src="https://github.com/ronan-macedo/LuccaStore/blob/main/src/web/LuccaStore.Web/src/assets/animated-logo.gif" alt="logo"/>
</p>
