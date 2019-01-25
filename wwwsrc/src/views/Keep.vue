<template>
  <div class="container">
    <div class="jumbotron">
      <div class="row">
        <h4 class="mb-3 col-md-6 col-lg-6">{{keep.name}}</h4>
        <div class="dropdown col-md-6 col-lg-6">
          <button class="btn no-radius btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false">
            Keep {{keep.keeps}}
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <a v-for="vault in vaults" class="dropdown-item" href="#" @click="createVK(vault.id, keep.id)">{{vault.name}}</a>
          </div>
        </div>
      </div>
      <img class="max-width keepImg" :src="keep.img">
      <p class="mt-3">{{keep.description}}</p>

    </div>

  </div>
</template>

<script>
  export default {
    name: 'Keep',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getKeepById', this.keepId)
    },
    computed: {
      keep() {
        return this.$store.state.CurrentKeep
      },
      vaults() {
        return this.$store.state.UserVaults
      },
    },
    methods: {
      createVK(vaultID, keepID) {
        this.$store.dispatch('createVK', { vaultId: vaultID, keepId: keepID })
      }
    },
    props: ['keepId']
  }

</script>

<style>
  .keepImg {
    max-width: 80vh;
    border-radius: .2rem;
  }
</style>