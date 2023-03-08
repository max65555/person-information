function Greeting() {
    console.log("the greeting from js");
}

var MyElementReference = MyElementReference || {}
MyElementReference.setFocus = function (element) {
    console.log("call js function")
    element.focus();
}
function AutoFocusFunction(element) {
    console.log("Call js function");
    element.focus();
}
function TheCallFromDotNet(dotnetObject) {
    let greetingFromJS = "u did me wrong";
    console.log("JS")
    dotnetObject.invokeMethodAsync("ConsoleApp", greetingFromJS);
}
