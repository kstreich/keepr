<template>
  <div class="home">
    <h1>Welcome Home</h1>

    <div class="card-columns count">
      <div v-for="keep in keeps">
        <div class="card">
          <img class="card-img-top" :src='keep.img'>
          <div class="card-body">
            <h4 class="card-title">{{keep.name}}</h4>
            <p class="card-text">{{keep.description}}</p>
            <div class="btn-group" role="group" aria-label="Basic example">
              <div class="dropdown">
                <button class="btn no-radius btn-info dropdown-toggle" type="button" id="dropdownMenuButton"
                  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  Keep {{keep.keeps}}
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                  <a v-for="vault in vaults" class="dropdown-item" href="#" @click="createVK(vault.id, keep.id)">{{vault.name}}</a>
                </div>
              </div>
              <button type="button" @click="addViewCount(keep.id)" class="no-radius btn btn-secondary">
                <router-link :to="{name: 'keep', params: {keepId: keep.id}}">View {{keep.views}}</router-link>
              </button>
              <button class="btn btn-secondary no-radius" data-href="https://developers.facebook.com/docs/plugins/"
                data-layout="button_count" data-size="small" data-mobile-iframe="true"><a target="_blank" href="https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2Fplugins%2F&amp;src=sdkpreparse"
                  class="fb-xfbml-parse-ignore">Share</a></button>
            </div>
            <!-- <div class="row mt-2">
              <div class="col-4">{{keep.keeps}} </div>
              <div class="col-4"> {{keep.views}} </div>
              <div class="col-4"> {{keep.shares}} </div>
            </div> -->
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
    data() {
      return {
      }
    },
    mounted() {
      this.$store.dispatch("getAllKeeps")
    },
    computed: {
      keeps() {
        return this.$store.state.Allkeeps
      },
      vaults() {
        return this.$store.state.UserVaults
      }
    },
    methods: {
      addViewCount(keepId) {
        this.$store.dispatch('addViewCount', keepId)
      },
      // addKeepCount(keepId) {
      //   this.$store.dispatch('addKeepCount', keepId)
      // },
      createVK(vaultID, keepID) {
        this.$store.dispatch('createVK', { vaultId: vaultID, keepId: keepID })
      }
    },
    watch: {

    },
    components: {

    }
  };
</script>

<style>
  .no-radius {
    border-radius: 0px;
  }
</style>