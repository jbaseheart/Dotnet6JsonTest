# Dotnet6JsonTest
Project to demonstrate how default Json input deserialization is handled in .Net 6

Launch the WebAPI project and then issue a POST request to `http://localhost:5192/Test` with the following Json payload:
```
{
  "name": "string",
  "gender": "Male",
  "age": null
}
```
