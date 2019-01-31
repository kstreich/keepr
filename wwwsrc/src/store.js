import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import Swal from 'sweetalert2'

Vue.use(Vuex)

let production = !window.location.host.includes('localhost')
let baseURL = production ? "" : "//localhost:5000"

let auth = Axios.create({
  baseURL: baseURL + "/auth/",
  timeout: 5000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseURL + "/api/",
  timeout: 5000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    Allkeeps: [],
    UserVaults: [],
    CurrentVault: {},
    UserKeeps: [],
    CurrentKeep: {},
    VaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setAllKeeps(state, keeps) {
      state.Allkeeps = keeps
    },
    setUserVaults(state, vaults) {
      state.UserVaults = vaults
    },
    setCurrentVault(state, vault) {
      state.CurrentVault = vault
    },
    setUserKeeps(state, keeps) {
      state.UserKeeps = keeps
    },
    setCurrentKeep(state, keep) {
      state.CurrentKeep = keep
    },
    setVKs(state, vks) {
      state.VaultKeeps = vks
    },
    logout(state) {
      state.user = {}
    }

  },
  actions: {

    //VAULTS
    getAllVaults({ commit, dispatch }) {
      api.get('/vaults')
        .then(res => {
          console.log("Vaults ->", res.data)
          commit('setUserVaults', res.data)
        })
    },
    createVault({ commit, dispatch }, vaultData) {
      api.post('vaults', vaultData)
        .then(res => {
          commit('setUserVaults', res.data)
          dispatch('getAllVaults')
        })
    },
    getVaultById({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId)
        .then(res => {
          console.log('CurrentVault ->', res.data)
          commit('setCurrentVault', res.data)
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          console.log('Vault deleted!')
          dispatch('getAllVaults')
        })
    },

    //KEEPS
    createKeep({ commit, dispatch }, keep) {
      api.post('/keeps', keep)
        .then(res => {
          console.log("Keep Created!")
          dispatch('getKeepsByUID')
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          console.log("Keep Deleted!")
          dispatch('getKeepsByUID')
        })
    },

    getAllKeeps({ commit, dispatch }) {
      api.get('/keeps')
        .then(res => {
          console.log("Keeps ->", res.data)
          commit('setAllKeeps', res.data)
        })
    },

    getKeepsByUID({ commit, dispatch }) {
      api.get('keeps/user')
        .then(res => {
          console.log("User Keeps ->", res.data)
          commit('setUserKeeps', res.data)
        })
    },
    getKeepById({ commit, dispatch }, keepId) {
      api.get("keeps/" + keepId)
        .then(res => {
          console.log("Keep ->", res.data)
          commit('setCurrentKeep', res.data)
        })
    },

    addViewCount({ commit, dispatch }, keepId) {
      api.put('keeps/' + keepId + "/views")
        .then(res => {
          console.log("View updated")
          dispatch('getAllKeeps')
        })
    },
    addKeepCount({ commit, dispatch }, keepId) {
      api.put('keeps/' + keepId + "/keeps")
        .then(res => {
          console.log("Keep updated")
          dispatch('getAllKeeps')
        })
    },

    //VAULTKEEPS
    createVK({ commit, dispatch }, vkData) {
      api.post('vaultkeep', vkData)
        .then(res => {
          console.log('VK created!')
          dispatch('addKeepCount', vkData.keepId)
        })
    },
    getVKByVId({ commit, dispatch }, vaultId) {
      api.get('vaultkeep/' + vaultId)
        .then(res => {
          console.log('VK ->', res.data)
          commit('setVKs', res.data)
        })
    },
    deleteVK({ commit, dispatch }, vk) {
      api.put('vaultkeep/', vk)
        .then(res => {
          console.log("VK deleted!")
          dispatch('getVKByVId', vk.vaultId)
        })
    },

    //AUTH 
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          console.log("User ->", res.data)
          commit('setUser', res.data)
          dispatch('getAllVaults')
          // router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
          dispatch('getAllVaults')
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('logout')
          router.push({ name: 'login' })
        })
    }
  }
})