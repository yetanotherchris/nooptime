<template>
	<div>
		<div class="row">
			<div class="col-md-6">
				<h4>Manage</h4>
			</div>
			<div class="col-md-6">
				<button class="btn btn-primary" style="float:right;font-size:12px;" data-toggle="modal" data-target="#add-modal">New uptime check</button>
			</div>	
		</div>
		<div class="row">
			<div class="col-md-12">			
				<ManageList/>
			</div>
		</div>
		<AddEditForm />
	</div>
</template>

<script>
import ManageList from "../components/manage/ManageList.vue";
import AddEditForm from "../components/manage/AddEditForm.vue";


export default {
	components: {
		ManageList, AddEditForm
	}
};
</script>