<template>
  <div class="well">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
          <h4 class="modal-title">Contact</h4>
        </div>
        <div class="modal-body">
          <p>Feel free to contact us for any issues you might have with our products.</p>
          <div class="row">
            <div class="col-xs-6">
              <label>Name</label>
              <input type="text" class="form-control" placeholder="Name">
            </div>
            <div class="col-xs-6">
              <label>Email</label>
              <input type="text" class="form-control" placeholder="Email">
            </div>
          </div>
          <div class="row">
            <div class="col-xs-12">
              <label>Message</label>
              <textarea class="form-control" rows="3">Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac</textarea>
            </div>
          </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
          <button type="button" class="btn btn-success">Send</button>
        </div>
  </div>
</template>