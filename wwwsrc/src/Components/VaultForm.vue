<template>
  <div class="">

    <span>
      <button class="btn-clear" data-toggle="modal" data-target="#exampleModal">
        <i class="fas fa-plus"></i>
      </button>Create a Vault
    </span>


    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            Here is the modal body where all the text goes
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
          </div>
        </div>
      </div>
    </div>





  </div>
</template>

<script>
  export default {
    name: 'VaultForm',
    data() {
      return {

      }
    },
    computed: {},
    methods: {}
  }

</script>

<style>


</style>