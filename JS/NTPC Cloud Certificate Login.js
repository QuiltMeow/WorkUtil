// ==UserScript==
// @name NTPC Cloud Certificate Login
// @namespace https://www.quilt.idv.tw/
// @version 0.02
// @description NTPC Cloud Certificate Login
// @author EW_Quilt
// @match http://cloud2.ntpc.gov.tw/
// @icon https://www.google.com/s2/favicons?sz=64&domain=www.ntpc.gov.tw
// @grant none
// ==/UserScript==

(function() {
    "use strict";

    $(document).ready(() => {
        setTimeout(() => {
            document.querySelectorAll("button")[1].click();
        }, 1000);
    });
})();