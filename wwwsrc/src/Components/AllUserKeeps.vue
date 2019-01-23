<template>
  <div class="container-fluid">

    <div class="card-columns count mt-5">
      <div v-for="keep in userKeeps">
        <div class="card">
          <img class="card-img-top" :src='keep.img'>
          <div class="card-img-overlay">
            <div class="dropdown">
              <button class="btn btn-sm btn-info dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown"
                aria-haspopup="true" aria-expanded="false">
                Add to Vault
              </button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <a v-for="vault in userVaults" class="dropdown-item" href="#" @click="createVK(vault.id, keep.id)">{{vault.name}}</a>
              </div>
            </div>
          </div>
          <router-link :to="{name: 'keep', params: {keepId: keep.id}}">
            <h5 class="card-title">{{keep.name}}</h5>
            <p>{{keep.description}}</p>
          </router-link>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: 'UserKeeps',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getKeepsByUID')
    },
    computed: {
      userKeeps() {
        return this.$store.state.UserKeeps
      },
      userVaults() {
        return this.$store.state.UserVaults
      }
    },
    methods: {
      //FINISH WITH THIS METHOD to create a vaultkeep, not sure what to do after that...
      createVK(vaultID, keepID) {
        this.$store.dispatch('createVK', { vaultId: vaultID, keepId: keepID })
      }
    }
  }

</script>

<style>
  .card-img-overlay {
    padding: 0;
  }

  .cardText {
    display: flex;
    justify-content: flex-end;
    color: rgb(18, 232, 200);
  }
</style>