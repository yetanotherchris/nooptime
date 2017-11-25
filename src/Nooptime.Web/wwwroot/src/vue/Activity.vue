<template>
	<div>
		<svg id="status-svg"></svg>
	</div>
</template>

<script>
const Snap = require("snapsvg");

$(document).ready(function()
{
	var s = Snap('#status-svg');
	var radius = 6;

	for (var i = 1; i < 24; i++)
	{
	// Lets create big circle in the middle:
	var bigCircle = s.circle(50 + (i * (radius *2)), 10, radius);
	// By default its black, lets change its attributes
	
	var color = "#bada55";
	if (i % 11 == 0 )
		var color = "#CC0000";
		
	bigCircle.attr({
		fill: color,
	});    
	}
});
</script>