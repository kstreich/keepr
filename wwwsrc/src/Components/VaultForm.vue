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
            <h5 class="modal-title" id="exampleModalLabel">Create a Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createVault()">
              <div class="form-group row">
                <label for="vaultName">Name</label>
                <input type="text" class="form-control" v-model="vault.name">
              </div>
              <div class="form-group row">
                <label for="vaultDesc">Description</label>
                <input type="text" class="form-control" v-model="vault.description">
              </div>
              <button type="submit" class="btn btn-sm btn-light">Submit</button>
            </form>
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
        vault: {
          name: "",
          description: "",
          isPrivate: 1
        }
      }
    },
    computed: {},
    methods: {
      createVault() {
        this.$store.dispatch('createVault', this.vault)
      }
    }
  }

</script>

<style>


</style>