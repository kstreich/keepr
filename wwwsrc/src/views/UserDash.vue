<template>
  <div class="">

  </div>
</template>

<script>
  export default {
    //ask about grabbing the user data and requesting the user id, if that should be done in the back end and how to do that?
    name: '',
    data() {
      return {

      }
    },
    beforemount() {
      this.$store.dispatch("authenticate")
    },
    mounted() {

      this.$store.dispatch('getAllVaults')
    },
    computed: {

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