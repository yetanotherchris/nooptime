<template>
  <tr>
    <td style="width:40%">
      {{ item.text }}
    </td>
    <td style="width:10%;text-align:middle">
      {{ item.checkType }}
    </td>
    <td style="width:10%;text-align:middle">
      {{ item.uptime }} %
    </td>
    <td style="width:40%;text-align:left">
      <svg v-bind:id="'svg-' + item.id" style="width:400px;margin-left:-30px;height:20px;" />     
    </td>
  </tr>
</template>

<script>
export default {
  props: {
    item: {
      type: Object,
      required: true
    }
  },
  mounted: function() 
  {
    const Snap = require("snapsvg");
    var snap = Snap("#svg-" +this.item.id);
    var radius = 6;

    for (var i = 1; i < this.item.checks.length; i++) {
      var offsetLeft = i * (radius * 2);
      var circle = snap.circle(50 + offsetLeft, 10, radius);

      var color = "#bada55";
      if (this.item.checks[i] == 0) 
      {
        color = "#CC0000";
      }

      circle.attr({
        fill: color
      });
    }
  }
};
</script>