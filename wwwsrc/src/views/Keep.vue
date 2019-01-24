<template>
  <div class="container">
    <div class="jumbotron">
      <h4 class="mb-3">{{keep.name}}</h4>
      <img class="max-width keepImg" :src="keep.img">
      <p class="mt-3">{{keep.description}}</p>
    </div>

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
      this.$store.dispatch('getKeepById', this.keepId)
    },
    computed: {
      keep() {
        return this.$store.state.CurrentKeep
      }
    },
    methods: {},
    props: ['keepId']
  }

</script>

<style>
  .keepImg {
    max-width: 80vh;
    border-radius: .2rem;
  }
</style>