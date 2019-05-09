# GENYA的個人網頁

### Windows
- 請至[微軟.Net Core下載網站](https://dotnet.microsoft.com/download/dotnet-core/2.2)安裝.NET Core 2.2.105 或更高版本
- 安裝後，開啟 新的CMD視窗 輸入`dotnet -version`可以顯示當前版本。

使用`CMD`進入儲存repo的資料夾，輸入指令如下：

```cmd
dotnet ef database update
dotnet run
```

等待CMD出現：
```cmd
Now listening on: https://localhost:XXXX
Now listening on: http://localhost:XXXX
```
(XXXX為Port號碼，請自行取代！)

即可使用瀏覽器，複製上列其中一個網址來瀏覽網頁。
