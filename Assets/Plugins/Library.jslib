mergeInto(LibraryManager.library, {
  GetPlayerData: function () {
    myGameInstance.SendMessage('YandexSDK', 'SetName', player.getName());
    myGameInstance.SendMessage('YandexSDK', 'SetPhoto', player.getPhoto("medium"));

    console.log(player.getName());
    console.log(player.getPhoto("medium"));
  },

  GetLang: function () {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },
});