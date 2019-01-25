<template>
  <div class="container-fluid">

    <div class="card-columns count mt-5">
      <div v-for="keep in userKeeps">

        <div class="card">
          <img class="card-img-top" :src='keep.img'>
          <div class="dropdown cardSectionTp">
            <button class="btn btn-sm btn-info btn-clear dropdown-toggle" type="button" id="dropdownMenuButton"
              data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              Add to Vault
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <a v-for="vault in userVaults" class="dropdown-item" href="#" @click="createVK(vault.id, keep.id)">{{vault.name}}</a>
            </div>
          </div>
          <router-link :to="{name: 'keep', params: {keepId: keep.id}}">
            <h5 class="card-title mt-3">{{keep.name}}</h5>
            <p>{{keep.description}}</p>
          </router-link>
          <div class="cardSectionBt">
            <i class="fab fa-korvue"></i> {{keep.keeps}} <i class="far fa-eye"></i> {{keep.views}}
            <button @click="deleteKeep(keep.id)" class="btn-clear"><i class="fas fa-trash"></i></button>
          </div>
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
      },
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId)
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

  .cardSectionBt {
    border-top: 1px solid rgba(0, 0, 0, .125)
  }

  .cardSectionTp {
    border-bottom: 1px solid rgba(0, 0, 0, .125)
  }
</style>