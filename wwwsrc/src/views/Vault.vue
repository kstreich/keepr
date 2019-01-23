<template>
  <div class="">
    <h4>{{vault.name}}</h4>
    <h6 class="mb-5">{{vault.description}}</h6>

    <div class="card-columns count">
      <div v-for="keep in vk">
        <div class="card">
          <img class="card-img-top" :src='keep.img'>
          <div class="card-body">
            <h4 class="card-title">{{keep.name}}</h4>
            <p class="card-text">{{keep.description}}</p>
            <div class="btn-group" role="group" aria-label="Basic example">
              <button type="button" class="btn btn-secondary">Keep</button>
              <button type="button" class="btn btn-secondary">Share</button>
              <button type="button" class="btn btn-secondary">View</button>
            </div>
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
    beforemount() {
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
    methods: {},
    components: {
      KeepForm
    }
  }

</script>

<style>


</style>