<template>
  <div class="container">
    <VaultForm class="mt-5"></VaultForm>
    <div class="card-columns count mt-5">
      <div v-for="vault in vaults">
        <div class="card">
          <h5 class="card-title">{{vault.name}}</h5>
          <p>{{vault.description}}</p>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  import VaultForm from '@/Components/VaultForm.vue'
  export default {
    //ask about grabbing the user data and requesting the user id, if that should be done in the back end and how to do that?
    name: '',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getAllVaults')
    },
    computed: {
      vaults() {
        return this.$store.state.UserVaults
      },

    },
    methods: {

    },
    watch: {

    },
    components: {
      VaultForm
    },
    props: [

    ]
  }

</script>

<style>
  .btn-clear {
    background-color: rgba(240, 248, 255, 0);
    border: none;
    cursor: pointer;
  }

  .vaultStyle {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
  }
</style>