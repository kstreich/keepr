<template>
  <div class="">

  </div>
</template>

<script>
  export default {
    name: '',
    data() {
      return {

      }
    },
    beforemount() {
      this.$store.dispatch("authenticate")
    },
    mounted() {

      this.$store.dispatch('getAllVaults', this.user.id)
    },
    computed: {
      user() {

        return this.$store.state.user.id
      }
    },
    methods: {

    },
    watch: {

    },
    components: {

    }
  }

</script>

<style>


</style>