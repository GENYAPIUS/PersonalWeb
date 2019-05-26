"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (content1, content2, content3, user, message) {
    //置換XSS可能字
    user = user.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    message = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //組合字串並使用HTML
    var contentEncode = content1 + user + content2 + message + content3;
    var div = document.createElement("div");
    div.innerHTML = contentEncode;
    document.getElementById("messagesList").appendChild(div);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});