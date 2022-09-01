(function (global, factory) {
  if (typeof define === "function" && define.amd) {
    define("/apps/forum", ["jquery"], factory);
  } else if (typeof exports !== "undefined") {
    factory(require("jquery"));
  } else {
    var mod = {
      exports: {}
    };
    factory(global.jQuery);
    global.appsForum = mod.exports;
  }
})(this, function (_jquery) {
  "use strict";

  _jquery = babelHelpers.interopRequireDefault(_jquery);
  // (function(document, window, $) {
  //   'use strict';
  //
  //   window.AppForum = App.extend({
  //     run: function(next) {
  //       next();
  //     }
  //   });
  //
  //   $(document).ready(function() {
  //     AppForum.run();
  //   });
  // 
  (0, _jquery.default)(document).ready(function () {
    AppForum.run();
  });
});