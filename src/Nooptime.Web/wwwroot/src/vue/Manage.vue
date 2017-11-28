<template>
	<div>
		<div class="row">
			<div class="col-md-6">
				<h4>Manage</h4>
			</div>
			<div class="col-md-6">
				<button class="btn btn-primary" style="float:right;" data-toggle="modal" data-target="#add-modal">New uptime check</button>
			</div>	
		</div>
		<div class="row">
			<div class="col-md-12">			
				<UptimeCheckList/>
			</div>
		</div>
		<AddEditForm />
	</div>
</template>

<script>
import UptimeCheckList from "./components/manage/UptimeCheckList.vue";
import AddEditForm from "./components/manage/AddEditForm.vue";


export default {
	components: {
		UptimeCheckList, AddEditForm
	}
};
</script>