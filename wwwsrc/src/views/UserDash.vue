<template>
  <div class="">
    <div class="row compSpacing mt-5">
      <VaultForm></VaultForm>
      <KeepForm></KeepForm>
    </div>

    <div class="card-columns count vSpacing">
      <div v-for="vault in vaults">
        <div class="card">
          <router-link :to="{name: 'vault', params: {vaultId: vault.id}} ">
            <h5 class="card-title">{{vault.name}}</h5>
            <p>{{vault.description}}</p>
          </router-link>
          <button @click="deleteVault(vault.id)" class="btn-clear"><i class="fas fa-trash"></i></button>
        </div>
      </div>
    </div>
    <h4>All of your Keeps</h4>
    <AllUserKeeps></AllUserKeeps>
  </div>
</template>

<script>
  import VaultForm from '@/Components/VaultForm.vue'
  import KeepForm from '@/Components/KeepForm.vue'
  import AllUserKeeps from '@/Components/AllUserKeeps.vue'
  export default {
    //ask about grabbing the user data and requesting the user id, if that should be done in the back end and how to do that?
    name: '',
    data() {
      return {

      }
    },
    computed: {
      vaults() {
        return this.$store.state.UserVaults
      },

    },
    methods: {
      deleteVault(vaultId) {
        this.$store.dispatch('deleteVault', vaultId)
      }
    },
    watch: {
      // vaults(val) {
      //   this.$store.dispatch('getAllVaults')
      // }
    },
    components: {
      VaultForm,
      KeepForm,
      AllUserKeeps
    },
    props: [

    ]
  }

</script>

<style>
  .btn-clear {
    background-color: rgba(240, 248, 255, 0);
    border: none;
    cursor: pointer;
  }

  .vaultStyle {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
  }

  .compSpacing {
    display: flex;
    justify-content: space-evenly;
  }

  .vSpacing {
    padding: 4rem;
  }
</style>