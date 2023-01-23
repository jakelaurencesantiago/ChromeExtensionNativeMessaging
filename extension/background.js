"use strict";

const nativePort = chrome.runtime.connectNative("native_message_name.json");

//listener for messages from native host
nativePort.onMessage.addListener(msg => {
    console.log("native response");
    console.log(msg);
});

//event listener
nativePort.onDisconnect.addListener(() => {
    console.log("native port disconnected");
});

chrome.action.onClicked.addListener(tab => {
   nativePort.postMessage({message: "PING"});
});