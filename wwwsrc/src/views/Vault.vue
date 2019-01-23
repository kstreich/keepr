<template>
  <div class="">
    <h4>{{vault.name}}</h4>
    <h6 class="mb-5">{{vault.description}}</h6>



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
    mounted() {
      this.$store.dispatch('getVaultById', this.vaultId)
    },
    computed: {
      vault() {
        return this.$store.state.CurrentVault
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