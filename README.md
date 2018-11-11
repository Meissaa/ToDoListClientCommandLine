# ToDoListClientCommandLine

Todolist is a simple and very fast task manager for the command line.

## Commands

* Login
```
<BASE_API_URL> LOGIN <username> <passwrod>
```
* Register
```
<BASE_API_URL> REGISTER <username> <passwrod> <firstname> <lastname> <emailaddress>
```
* GetLists
```
<BASE_API_URL> GETLISTS
```
* GetDetails
```
<BASE_API_URL> GETDETAILS <listid>
```
* CreateList
```
<BASE_API_URL> CREATELIST <name> <date>
```
* UpdateList
```
<BASE_API_URL> UPDATELIST <listid> <name> <date>
```
* RemoveList
```
<BASE_API_URL> REMOVELIST <listid>
```
* CreateTask
```
<BASE_API_URL> CREATETASK <listid> <text> <iscompleted> <createdate> (<completedate>)
```
* RemoveTask
```
<BASE_API_URL> REMOVETASK <listid> <taskid>
```
* UpdateTask
```
<BASE_API_URL> UPDATETASK <listid> <taskid> <listid> <text> <iscompleted> <createdate> (<completedate>)
```
