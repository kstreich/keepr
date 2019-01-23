<template>
  <div class="">
    <span>
      <button class="btn-clear" data-toggle="modal" data-target="#example">
        <i class="fas fa-plus"></i>
      </button>Create a Keep
    </span>


    <!-- Modal -->
    <div class="modal fade" id="example" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Create a Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createKeep()" id="keepForm">
              <div class="form-group row">
                <label for="keepName">Name</label>
                <input type="text" class="form-control" v-model="keep.name">
              </div>
              <div class="form-group row">
                <label for="keepDesc">Description</label>
                <input type="text" class="form-control" v-model="keep.description">
              </div>
              <div class="form-group row">
                <label for="keepImg">Image Url</label>
                <input type="text" class="form-control" v-model="keep.img">
              </div>

              <label class="container">Make Public?
                <input name="public" type="checkbox" v-model="keep.isPrivate" value="1">
                <span class="checkmark"></span>
              </label>
              {{keep.isPrivate}}

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
    name: 'KeepForm',
    data() {
      return {
        keep: {
          name: "",
          description: "",
          img: "",
          isPrivate: 0
        }
      }
    },
    computed: {},
    methods: {
      createKeep() {

        if (this.keep.isPrivate === true) {
          this.keep.isPrivate = 0
        }
        else {
          this.keep.isPrivate = 1
        }
        this.$store.dispatch('createKeep', this.keep)
        document.getElementById("keepForm").reset()

      }
    }
  }

</script>

<style>


</style>