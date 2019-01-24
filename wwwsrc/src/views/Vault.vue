<template>
  <div class="">
    <h1>Vault</h1>
    <h4>{{vault.name}}</h4>
    <h6 class="mb-5">{{vault.description}}</h6>

    <div class="card-columns count">
      <div v-for="keep in vk">
        <div class="card">
          <img class="card-img-top" :src='keep.img'>
          <div class="card-body">
            <h4 class="card-title">{{keep.name}}</h4>
            <p class="card-text">{{keep.description}}</p>
            <button @click="removeKfromV(keep.id)" class="btn-clear"><i class="fas fa-minus"></i> </button>
          </div>
        </div>
      </div>
    </div>


  </div>
</template>

<script>
  import KeepForm from '@/Components/KeepForm.vue'
  export default {
    name: 'Vault',
    props: ['vaultId'],
    data() {
      return {

      }
    },
    beforeMount() {
      this.$store.dispatch('getVaultById', this.vaultId)
    },
    mounted() {
      this.$store.dispatch('getVKByVId', this.vaultId)
    },
    computed: {
      vault() {
        return this.$store.state.CurrentVault
      },
      vk() {
        return this.$store.state.VaultKeeps
      }

    },
    methods: {
      removeKfromV(keepID) {
        this.$store.dispatch('deleteVK', { keepId: keepID, vaultId: this.vault.id })
      }
    },
    components: {
      KeepForm
    }
  }

</script>

<style>
  @media (max-width: 34em) {
    .card-columns {
      -webkit-column-count: 2;
      -moz-column-count: 2;
      column-count: 2;
    }
  }

  @media (min-width: 34em) {
    .card-columns {
      -webkit-column-count: 2;
      -moz-column-count: 2;
      column-count: 2;
    }
  }

  @media (min-width: 48em) {
    .card-columns {
      -webkit-column-count: 3;
      -moz-column-count: 3;
      column-count: 3;
    }
  }

  @media (min-width: 62em) {
    .card-columns {
      -webkit-column-count: 4;
      -moz-column-count: 4;
      column-count: 4;
    }
  }

  @media (min-width: 75em) {
    .card-columns {
      -webkit-column-count: 5;
      -moz-column-count: 5;
      column-count: 5;
    }
  }

  @media (max-width: 34em) {
    .btn {
      padding-left: 0px;
      padding-right: 7px;
    }
  }
</style>