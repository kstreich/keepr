<template>
  <div class="home">
    <h1>Welcome Home, this is where all of the keeps are going to be</h1>

    <div class="card-columns count">
      <div v-for="keep in keeps">
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
  //Place request to grab all of the keeps
  export default {
    name: "home",
    beforemount() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    mounted() {
      this.$store.dispatch("getAllKeeps")
    },
    computed: {
      keeps() {
        return this.$store.state.Allkeeps
      }
    },
    methods: {

    },
    watch: {

    },
    components: {

    }
  };
</script>

<style>

</style>