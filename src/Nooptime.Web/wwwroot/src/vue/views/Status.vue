<template>
	<div class="row">
		<div class="col-md-12">
			<h4>Status</h4>
			<StatusList />
		</div>
	</div>
</template>

<script>
import StatusList from "../components/status/StatusList.vue";

export default {
	components: {
		StatusList
	}
};
</script>