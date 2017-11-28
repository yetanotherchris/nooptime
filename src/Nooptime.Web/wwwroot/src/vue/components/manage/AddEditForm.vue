<template>
	<div id="add-modal" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" style="font-size: 1.25rem; margin-top:0px;margin-bottom:0px;">New status check</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label for="name">Name</label>
                            <input type="text" class="form-control" id="name" placeholder="Enter name">
                            <small id="emailHelp" class="form-text text-muted">The name of the check.</small>
                        </div>
                        <div class="form-group">
                            <label for="type">Type</label>
                            <select id="type" class="form-control">
                                <option value="HTTP">HTTP</option>
                                <option value="SQL">SQL</option>
                                <option value="ping">Ping</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="interval">Interval</label>
                            <input type="text" class="form-control" id="interval" placeholder="e.g. 1 minute 30 seconds">
                        </div>
                        <div class="form-check">
                            <label class="form-check-label">
                                <input type="checkbox" class="form-check-input" checked>Enabled
                            </label>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success">Save</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</template>