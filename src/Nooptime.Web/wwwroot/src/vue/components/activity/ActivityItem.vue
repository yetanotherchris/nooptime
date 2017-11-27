<template>
  <li style="list-style:none;">
    <svg v-bind:id="'svg-' +item.id" style="width:12px;height:12px" />
    <strong>{{ item.name }}</strong>&nbsp;{{ (item.success === true ? "was sucessful." : "failed (" +item.errorMessage+ ")")}}
  </li>
</template>

<script>
export default {
  props: {
    item: {
      type: Object,
      required: true
    }
  },
  mounted: function() {
    const Snap = require("snapsvg");
    var snap = Snap("#svg-" + this.item.id);
    var radius = 3;
    var circle = snap.circle(6,6, radius);
    var color = "#CC0000";

    if (this.item.success === true) {
      color = "#bada55";
    }

    circle.attr({
      fill: color
    });
  }
};
</script>