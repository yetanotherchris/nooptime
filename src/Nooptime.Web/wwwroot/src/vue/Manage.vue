<template>
	<div>
		<div class="row">
			<div class="col-md-6">
				<h4>Manage</h4>
			</div>
			<div class="col-md-6">
				<button class="btn btn-primary pull-right" @click="show = !show">New uptime check</button>
			</div>	
		</div>
		<div class="row">
			<div class="col-md-12">			
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
	}
};
</script>