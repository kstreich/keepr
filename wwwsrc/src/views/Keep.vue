<template>
  <div class="">


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
      this.store.dispatch('getKeepById', this.keepId)
    },
    computed: {},
    methods: {},
    props: ['keepId']
  }

</script>

<style>


</style>