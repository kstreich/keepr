<template>
  <div class="">
    <h4>{{vault.name}}</h4>
    <h6>{{vault.description}}</h6>

  </div>
</template>

<script>
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
    methods: {}
  }

</script>

<style>


</style>