<template>
	<div>
		<div class="row">
			<div class="col-md-12">
				<button class="btn btn-primary pull-right" @click="show = !show">New uptime check</button>
			</div>
			<div class="col-md-10">&nbsp;</div>
		</div>
		<div class="row">
			<div class="col-md-12">
				<h4>All items</h4>
				<UptimeCheckList v-if="!show"/>
				<transition name="bounce">
					<AddEditForm v-if="show"/>
				</transition>
			</div>
		</div>
	</div>
</template>

<script>
import UptimeCheckList from "./components/manage/UptimeCheckList.vue";
import AddEditForm from "./components/manage/AddEditForm.vue";

export default {
	components: {
		UptimeCheckList,
		AddEditForm
	},
	props: {
		show: {
			type: Boolean,
			required: true
		}
	}
};
</script>

<style scoped>
#app {
	font-family: "Avenir", Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
	text-align: center;
	color: #2c3e50;
	margin-top: 60px;
}

img {
	width: 200px;
	height: 200px;
}

h1,
h2 {
	font-weight: normal;
}

ul {
	list-style-type: none;
	padding: 0;
}

li {
	display: inline-block;
	margin: 0 10px;
}

a {
	color: #42b983;
}
</style>
