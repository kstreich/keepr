<template>
  <div class="container-fluid">

    <div class="card-columns count mt-5">
      <div v-for="keep in userKeeps">
        <div class="card">
          <router-link :to="{name: 'keep', params: {keepId: keep.id}} ">
            <img class="card-img-top" :src='keep.img'>
            <h5 class="card-title">{{keep.name}}</h5>
            <p>{{keep.description}}</p>
          </router-link>
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
      }
    },
    methods: {}
  }

</script>

<style>


</style>