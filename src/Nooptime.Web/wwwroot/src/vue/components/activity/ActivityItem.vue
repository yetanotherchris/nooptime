<template>
  <tr>
    <td style="width:40%;">
      {{ item.text }}
    </td>
    <td>
      {{ item.checkType }}
    </td>
    <td>
      {{ item.uptime }} %
    </td>
    <td style="width:40%">
      <svg v-bind:id="'svg' + item.id" style="width:400px;height:20px;"></svg>      
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
    var snap = Snap("#svg" +this.item.id);
    var radius = 6;

    for (var i = 1; i < this.item.checks.length; i++) {
      var offsetLeft = i * (radius * 2);
      var circle = snap.circle(50 + offsetLeft, 10, radius);

      var color = "#bada55";
      if (this.item.checks[i] == 0) var color = "#CC0000";

      circle.attr({
        fill: color
      });
    }
  }
};
</script>