(function() {
  var offsetHrs = 0;
  var offsetMin = 0;

  function updateClock() {
      var now = new Date();
      now.setHours(now.getHours() + offsetHrs)
      now.setMinutes(now.getMinutes() + offsetMin)
      var h = leadingZero(now.getHours());
      var m = leadingZero(now.getMinutes());
      var s = leadingZero(now.getSeconds());

      document.getElementById('hrs').innerHTML = h;
      document.getElementById('min').innerHTML = m;
      document.getElementById('sec').innerHTML = s;

      
      if (s % 2) { document.getElementById('led').className = "led-on"; } 
      else       { document.getElementById('led').className = "led-off"; }
  }
  function leadingZero(i) {
      if (i < 10) i = "0" + i; 
      return i;
  }
  function resetTime() {
    offsetHrs = 0;
    offsetMin = 0;
    updateClock();
  }
  function increaseHrs() {
    offsetHrs++;
    updateClock();
  }
  function increaseMin() {
    offsetMin++;
    updateClock();
  }
  function toggleSeconds() {
    var sec = document.getElementById('sec');
    sec.style.display = sec.style.display == "none" ? "" : "none";
  }
  
  var interval = setInterval(updateClock, 1000);
      
  document.getElementById('upper').addEventListener('click', resetTime, false);
  document.getElementById('hrs').addEventListener('click', increaseHrs, true);
  document.getElementById('min').addEventListener('click', increaseMin, false);
  document.getElementById('lower').addEventListener('click', toggleSeconds, true);
  document.body.onselectstart = function() { return false; } 
  
})();