function printMessages(msg1, msg2){
    console.log("Messages: " + msg1 + ", " + msg2);
}
printMessages.call(null, "Message 01", "Message 02");